﻿/*******************************************************************************
 * Copyright (C) 2017 Black Duck Software, Inc.
 * http://www.blackducksoftware.com/
 *
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements. See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership. The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License. You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied. See the License for the
 * specific language governing permissions and limitations
 * under the License.
 *******************************************************************************/
using Com.Blackducksoftware.Integration.Hub.Common.Net.Rest;
using System;
using System.Collections.Generic;

namespace Com.Blackducksoftware.Integration.Hub.Common.Net.Api.ResponseService
{
    public class HubResponseService
    {
        internal RestConnection RestConnection { get; set; }

        public HubResponseService(RestConnection restConnection)
        {
            RestConnection = restConnection;
        }

        public List<T> GetAllItems<T>(string url) where T : HubView
        {
            HubPagedRequest request = new HubPagedRequest(RestConnection);
            request.SetUriFromString(url);
            return GetAllItems<T>(request);
        }

        public List<T> GetAllItems<T>(HubPagedRequest request) where T : HubView
        {
            List<T> allItems = new List<T>();
            int totalCount = 0;
            int currentOffset = Convert.ToInt32(request.QueryParameters[HubRequest.Q_OFFSET]);
            int limit = Convert.ToInt32(request.QueryParameters[HubRequest.Q_LIMIT]);

            HubPagedResponse<T> response = request.ExecuteGetForResponsePaged<T>();
            totalCount = response.TotalCount;
            allItems.AddRange(response.Items);
            while (allItems.Count < totalCount && currentOffset < totalCount)
            {
                currentOffset += limit;
                request.QueryParameters[HubRequest.Q_OFFSET] = Convert.ToString(currentOffset);
                response = request.ExecuteGetForResponsePaged<T>();
                allItems.AddRange(response.Items);
            }

            return allItems;
        }

        public T GetItem<T>(string url) where T : HubView
        {
            HubRequest request = new HubRequest(RestConnection);
            request.SetUriFromString(url);
            return GetItem<T>(request);
        }

        public T GetItem<T>(HubRequest request) where T : HubView
        {
            T response = request.ExecuteGetForResponse<T>();
            return response;
        }
    }
}
