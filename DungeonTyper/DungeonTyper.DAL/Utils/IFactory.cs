using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.DAL.Utils
{
    public interface IFactory<out T>
    {
        T Create();
    }
    public interface IFactory<out T, in TParameter>
    {
        T Create(TParameter parmeter);
    }
    public interface IFactory<out T, in TParameter1, in TParameter2>
    {
        T Create(TParameter1 parmeter1, TParameter2 parameter2);
    }
    public interface IFactory<out T, in TParameter1, in TParameter2, in TParameter3>
    {
        T Create(TParameter1 parmeter1, TParameter2 parameter2, TParameter3 parameter3);
    }
}
