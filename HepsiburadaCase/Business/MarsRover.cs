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
            StartX = sX;
            StartY = sY;
            _startDirection = sD;
            MaxX = mX;
            MaxY = mY;
        }

        public int StartX { get { return _startX; } set { _startX = value; } }
        public int StartY { get { return _startY; } set { _startY = value; } }
        public EDirect.Direction StartDirection { get { return _startDirection; } set { value = _startDirection; } }

        public int MaxX { get { return _maxX; } set { _maxX = value; } }
        public int MaxY { get { return _maxY; } set { _maxY = value; } }
        public bool CantMove { get; set; }

        /// <summary>
        /// Move method of Rover's
        /// </summary>
        /// <returns>bool</returns>
        public bool Move()
        {
            if (StartDirection == EDirect.Direction.N)
            {
                if (StartY + 1 > MaxY)
                    return false;
                StartY++;
            }

            if (StartDirection == EDirect.Direction.W)
            {
                if (StartX + 1 > MaxX)
                    return false;
                StartX++;
            }

            if (StartDirection == EDirect.Direction.E)
            {
                if (StartX -1 < 0)
                    return false;
                StartX--;
            }

            if (StartDirection == EDirect.Direction.S)
            {
                if (StartY -1 < 0)
                    return false;
                StartY--;
            }

            return true;
        }

        /// <summary>
        /// Turn Method of Rover's
        /// </summary>
        /// <param name="direction"></param>
        public void Turn(string direction)
        {
            switch (direction)
            {
                case "R":
                    switch (StartDirection)
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
                    switch (StartDirection)
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
