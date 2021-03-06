﻿using System.Collections.Generic;
using Newtonsoft.Json;
using Yoti.Auth.DocScan.Session.Create.Check;
using Yoti.Auth.DocScan.Session.Create.Task;

namespace Yoti.Auth.DocScan.Session.Create
{
    public class SessionSpecification
    {
        internal SessionSpecification(int clientSessionTokenTtl, int resourcesTtl, string userTrackingId, NotificationConfig notifications, List<BaseRequestedCheck> requestedChecks, List<BaseRequestedTask> requestedTasks, SdkConfig sdkConfig)
        {
            ClientSessionTokenTtl = clientSessionTokenTtl;
            ResourcesTtl = resourcesTtl;
            UserTrackingId = userTrackingId;
            Notifications = notifications;
            RequestedChecks = requestedChecks;
            RequestedTasks = requestedTasks;
            SdkConfig = sdkConfig;
        }

        [JsonProperty(PropertyName = "client_session_token_ttl")]
        public int ClientSessionTokenTtl { get; }

        [JsonProperty(PropertyName = "resources_ttl")]
        public int ResourcesTtl { get; }

        [JsonProperty(PropertyName = "user_tracking_id")]
        public string UserTrackingId { get; }

        [JsonProperty(PropertyName = "notifications")]
        public NotificationConfig Notifications { get; }

        [JsonProperty(PropertyName = "requested_checks")]
        public List<BaseRequestedCheck> RequestedChecks { get; }

        [JsonProperty(PropertyName = "requested_tasks")]
        public List<BaseRequestedTask> RequestedTasks { get; }

        [JsonProperty(PropertyName = "sdk_config")]
        public SdkConfig SdkConfig { get; }
    }
}