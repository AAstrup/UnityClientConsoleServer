﻿
using System;

public class MatchMessageHandler : IMessageHandler
{
    private IMatchEventHandler matchEventHandler;
    private MessageCommandHandlerClient commandHandler;
    ILogger logger;

    public MatchMessageHandler(ILogger logger,IMatchEventHandler matchEventHandler)
    {
        this.logger = logger;
        logger.Log("Match messagehandler started!");

        this.matchEventHandler = matchEventHandler;
        commandHandler = new MessageCommandHandlerClient();
        commandHandler.Add(typeof(Message_Response_GameState), new Handler_Response_GameState(logger,matchEventHandler));
        commandHandler.Add(typeof(Message_Update_MatchFinished), new Handler_Update_MatchFinished(logger,matchEventHandler));
    }

    public void Handle(object data)
    {
        logger.Log("Match messagehandler got data of type " + data.GetType());
        if (commandHandler.Contains(data.GetType()))
            commandHandler.Execute(data.GetType(), data);
        else
        {
            logger.Log("Data type UKNOWN! Type: " + data.GetType().ToString());
        }
    }

    internal void Init(Client client)
    {
    }
}