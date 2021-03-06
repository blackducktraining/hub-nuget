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
namespace Com.Blackducksoftware.Integration.Hub.Common.Net.Model.Enums
{
    public class VersionBomPolicyStatusOverallStatusEnum : HubEnum
    {
        public static readonly VersionBomPolicyStatusOverallStatusEnum IN_VIOLATION = new VersionBomPolicyStatusOverallStatusEnum("IN_VIOLATION");
        public static readonly VersionBomPolicyStatusOverallStatusEnum IN_VIOLATION_OVERRIDDEN = new VersionBomPolicyStatusOverallStatusEnum("IN_VIOLATION_OVERRIDDEN");
        public static readonly VersionBomPolicyStatusOverallStatusEnum NOT_IN_VIOLATION = new VersionBomPolicyStatusOverallStatusEnum("NOT_IN_VIOLATION");

        public VersionBomPolicyStatusOverallStatusEnum()
        {
        }

        public VersionBomPolicyStatusOverallStatusEnum(string value) : base(value)
        {
        }
    }
}
