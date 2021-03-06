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
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace Com.Blackducksoftware.Integration.Hub.Common.Net.Items
{
    public class ReportData
    {
        [JsonProperty(PropertyName = "projectName")]
        public string ProjectName { get; set; }

        [JsonProperty(PropertyName = "projectUrl")]
        public string ProjectURL { get; set; }

        [JsonProperty(PropertyName = "projectVersion")]
        public string ProjectVersion { get; set; }

        [JsonProperty(PropertyName = "projectVersionURL")]
        public string ProjectVersionURL { get; set; }

        [JsonProperty(PropertyName = "phase")]
        public string Phase { get; set; }

        [JsonProperty(PropertyName = "distrubution")]
        public string Distribution { get; set; }

        [JsonProperty(PropertyName = "components")]
        public List<BomComponent> Components { get; private set; }

        [JsonProperty(PropertyName = "totalComponents")]
        public int TotalComponents { get; private set; }

        [JsonProperty(PropertyName = "vulnerabilityRiskHighCount")]
        public int VulnerabilityRiskHighCount { get; private set; }

        [JsonProperty(PropertyName = "vulnerabilityRiskMediumCount")]
        public int VulnerabilityRiskMediumCount { get; private set; }

        [JsonProperty(PropertyName = "vulnerabilityRiskLowCount")]
        public int VulnerabilityRiskLowCount { get; private set; }

        [JsonProperty(PropertyName = "vulnerabilityRiskNoneCount")]
        public int VulnerabilityRiskNoneCount { get; private set; }


        [JsonProperty(PropertyName = "licenseRiskHighCount")]
        public int LicenseRiskHighCount { get; private set; }

        [JsonProperty(PropertyName = "licenseRiskMediumCount")]
        public int LicenseRiskMediumCount { get; private set; }

        [JsonProperty(PropertyName = "licenseRiskLowCount")]
        public int LicenseRiskLowCount { get; private set; }

        [JsonProperty(PropertyName = "licenseRiskNoneCount")]
        public int LicenseRiskNoneCount { get; private set; }
        

        [JsonProperty(PropertyName = "operationalRiskHighCount")]
        public int OperationalRiskHighCount { get; private set; }

        [JsonProperty(PropertyName = "operationalRiskMediumCount")]
        public int OperationalRiskMediumCount { get; private set; }

        [JsonProperty(PropertyName = "operationalRiskLowCount")]
        public int OperationalRiskLowCount { get; private set; }

        [JsonProperty(PropertyName = "operationalRiskNoneCount")]
        public int OperationalRiskNoneCount { get; private set; }

        public void SetComponents(List<BomComponent> components)
        {
            Components = components;

            VulnerabilityRiskHighCount = 0;
            VulnerabilityRiskMediumCount = 0;
            VulnerabilityRiskLowCount = 0;

            LicenseRiskHighCount = 0;
            LicenseRiskMediumCount = 0;
            LicenseRiskLowCount = 0;

            OperationalRiskHighCount = 0;
            OperationalRiskMediumCount = 0;
            OperationalRiskLowCount = 0;

            foreach (BomComponent component in components)
            {
                AddComponentValues(component);
            }
            TotalComponents = components.Count;

            VulnerabilityRiskNoneCount = TotalComponents - VulnerabilityRiskHighCount - VulnerabilityRiskMediumCount - VulnerabilityRiskLowCount;
            LicenseRiskNoneCount = TotalComponents - LicenseRiskHighCount - LicenseRiskMediumCount - LicenseRiskLowCount;
            OperationalRiskNoneCount = TotalComponents - OperationalRiskHighCount - OperationalRiskMediumCount - OperationalRiskLowCount;
        }

        public void AddComponentValues(BomComponent component)
        {
            if (component != null)
            {
                // Vulnerabilities
                if (component.SecurityRiskHighCount > 0)
                {
                    VulnerabilityRiskHighCount++;
                }
                else if (component.SecurityRiskMediumCount > 0)
                {
                    VulnerabilityRiskMediumCount++;
                }
                else if (component.SecurityRiskLowCount > 0)
                {
                    VulnerabilityRiskLowCount++;
                }

                // License
                if (component.LicenseRiskHighCount > 0)
                {
                    LicenseRiskHighCount++;
                }
                else if (component.LicenseRiskMediumCount > 0)
                {
                    LicenseRiskMediumCount++;
                }
                else if (component.LicenseRiskLowCount > 0)
                {
                    LicenseRiskLowCount++;
                }

                // Operational
                if (component.OperationalRiskHighCount > 0)
                {
                    OperationalRiskHighCount++;
                }
                else if (component.OperationalRiskMediumCount > 0)
                {
                    OperationalRiskMediumCount++;
                }
                else if (component.OperationalRiskLowCount > 0)
                {
                    OperationalRiskLowCount++;
                }
            }
        }

        public string HtmlEscape(string valueToEscape)
        {
            if(string.IsNullOrWhiteSpace(valueToEscape))
            {
                return null;
            }
            return WebUtility.HtmlEncode(valueToEscape);
        }
    }
}
