﻿using SharedClientServerGameObjectMessages;
using System;
using System.Collections.Generic;

namespace SharedClientServerGameObjectMessages
{
    [Serializable]
    public class Message_ServerResponse_RoundEnded
    {
        public int Winner;
        public List<PlayerScore> Scores;
    }
}