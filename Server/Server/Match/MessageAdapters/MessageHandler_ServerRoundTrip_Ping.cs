﻿using System;
using System.Collections.Generic;
using ServerGameObjectExtension;

namespace Match
{
    internal class MessageHandler_ServerRoundTrip_Ping : IMessageHandlerCommand
    {
        private ILogger logger;
        private Server_MessageSender messageSender;
        private MatchThread matchThread;
        private List<IServerExtension> serverExtensions;

        public MessageHandler_ServerRoundTrip_Ping(ILogger logger, Server_MessageSender messageSender, MatchThread matchThread, List<IServerExtension> serverExtensions)
        {
            this.logger = logger;
            this.messageSender = messageSender;
            this.matchThread = matchThread;
            this.serverExtensions = serverExtensions;
        }

        public Type GetMessageTypeSupported()
        {
            return typeof(Message_ServerRoundTrip_Ping);
        }

        public void Handle(object objData, Server_ServerClient client)
        {
            float ping = (((Message_ServerRoundTrip_Ping)objData).timeSend - matchThread.clock.GetTime())/2;
            client.UpdatePing(Math.Ceiling(ping));
        }
    }
}