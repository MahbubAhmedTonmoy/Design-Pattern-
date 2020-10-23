using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Behavioral.State
{
   // 2 Components 1) Context 2) State.Context hold State reference.

    /// <summary>
    /// state interface
    /// </summary>
    public interface IState
    {
        void Handle(VideoGame game);
    }

    public class StaredState : IState
    {
        public void Handle(VideoGame game)
        {
            if (!(game.CurrentState is stopState))
            {
               // game.ChangeState(new StaredState());
            }
        }
    }
    public class PausedState : IState
    {
        public void Handle(VideoGame game)
        {
            if (!(game.CurrentState is PausedState))
            {
                //game.ChangeState(new PausedState());
            }
        }
    }
    public class stopState : IState
    {
        public void Handle(VideoGame game)
        {
            if(!(game.CurrentState is stopState))
            {
                //game.ChangeState(new stopState());
            }
        }
    }

    ///<summary>
    ///context class
    ///</summary>
    public class VideoGame
    {
        public IState CurrentState { get; private set; }
        public void ChangeState(IState state)
        {
            this.CurrentState = state;
        }
        public void Operate()
        {
            CurrentState.Handle(this);
        }
    }
}
