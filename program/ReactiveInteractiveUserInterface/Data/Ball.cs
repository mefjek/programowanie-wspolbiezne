//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//_____________________________________________________________________________________________________________________________________

namespace TP.ConcurrentProgramming.Data
{
  internal class Ball : IBall
  {
    #region ctor

    internal Ball(Vector initialPosition, Vector initialVelocity, double boardWidth, double boardHeight, double diameter)
    {
      Position = initialPosition;
      Velocity = initialVelocity;
      this.boardWidth = boardWidth;
      this.boardHeight = boardHeight;
      this.diameter = diameter;

    }

    #endregion ctor

    #region IBall

    public event EventHandler<IVector>? NewPositionNotification;

    public IVector Velocity { get; set; }

    #endregion IBall

    #region private

    private Vector Position;
    private double boardWidth;
    private double boardHeight;
    private double diameter;

    private void RaiseNewPositionChangeNotification()
    {
      NewPositionNotification?.Invoke(this, Position);
    }

    internal void Move(Vector delta)
    {
      double newX = Position.x + delta.x;
      double newY = Position.y + delta.y;

      if (newX < 0)
      {
        newX = 0;
      }
      else if (newX > boardWidth - diameter)
      {
        newX = boardWidth - diameter;
      }
      if (newY < 0)
      {
        newY = 0;
      }
      else if (newY > boardHeight - diameter)
      {
        newY = boardHeight - diameter;
      }

      Position = new Vector(newX, newY);
      RaiseNewPositionChangeNotification();
    }

    #endregion private
  }
}