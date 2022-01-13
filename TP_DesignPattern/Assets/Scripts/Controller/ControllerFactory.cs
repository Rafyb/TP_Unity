
    public class ControllerFactory
    {
        public Command Create(CommandType cmdType)
        {
            Command cmd;
            switch (cmdType)
            {
                case CommandType.JUMP :
                    cmd = new CmdJump();
                    break;
                case CommandType.MOVE :
                    cmd = new CmdMove();
                    break;
                case CommandType.RESPAWN :
                    cmd = new CmdSpawn();
                    break;
                case CommandType.SHOOT :
                    cmd = new Command();
                    break;
                default:
                    cmd = new Command();
                    break;
            }

            return cmd;
        }
    }
