using MarsRoverBusiness.Interfaces;
using MarsRoverCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverBusiness
{
    public class MarsRover : IMarsRover
    {
        EDirect.Direction _startDirection;
        int _startX, _startY, _maxX, _maxY;

        public MarsRover(int sX, int sY, EDirect.Direction sD, int mX, int mY)
        {
            startX = sX;
            startY = sY;
            _startDirection = sD;
            maxX = mX;
            maxY = mY;
        }

        public int startX { get { return _startX; } set { _startX = value; } }
        public int startY { get { return _startY; } set { _startY = value; } }
        public EDirect.Direction startDirection { get { return _startDirection; } set { value = _startDirection; } }

        public int maxX { get { return _maxX; } set { _maxX = value; } }
        public int maxY { get { return _maxY; } set { _maxY = value; } }
        public bool CantMove { get; set; }

        public bool Move()
        {
            if (startDirection == EDirect.Direction.N)
            {
                if (startY + 1 > maxY)
                    return false;
                startY++;
            }

            if (startDirection == EDirect.Direction.W)
            {
                if (startX + 1 > maxX)
                    return false;
                startX++;
            }

            if (startDirection == EDirect.Direction.E)
            {
                if (startX -1 < 0)
                    return false;
                startX--;
            }

            if (startDirection == EDirect.Direction.S)
            {
                if (startY -1 < 0)
                    return false;
                startY--;
            }

            return true;
        }

        public void Turn(string direction)
        {
            switch (direction)
            {
                case "R":
                    switch (startDirection)
                    {
                        case EDirect.Direction.N:
                            _startDirection = EDirect.Direction.E;
                            break;
                        case EDirect.Direction.S:
                            _startDirection = EDirect.Direction.W;
                            break;
                        case EDirect.Direction.E:
                            _startDirection = EDirect.Direction.S;
                            break;
                        case EDirect.Direction.W:
                            _startDirection = EDirect.Direction.N;
                            break;
                    }
                    break;
                case "L":
                    switch (startDirection)
                    {
                        case EDirect.Direction.N:
                            _startDirection = EDirect.Direction.W;
                            break;
                        case EDirect.Direction.S:
                            _startDirection = EDirect.Direction.E;
                            break;
                        case EDirect.Direction.E:
                            _startDirection = EDirect.Direction.N;
                            break;
                        case EDirect.Direction.W:
                            _startDirection = EDirect.Direction.S;
                            break;
                    }
                    break;
            }
        }
    }
}
