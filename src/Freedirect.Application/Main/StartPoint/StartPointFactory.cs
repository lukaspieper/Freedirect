using System;

namespace Freedirect.Application.Main.StartPoint
{
    internal class StartPointFactory
    {
        private readonly string[] _args = Environment.GetCommandLineArgs();

        internal IStartPoint GetStartPoint()
        {
            IStartPoint startPoint;

            switch (_args.Length)
            {
                //start without specific parameter
                case 1:
                    startPoint = new ForegroundStartPoint();
                    break;
                //start with one specific parameter (should be the protocol)
                case 2:
                    startPoint = new BackgroundStartPoint(_args[1]);
                    break;
                //start with more parameter
                default:
                    startPoint = null;
                    break;
            }

            return startPoint;
        }
    }
}