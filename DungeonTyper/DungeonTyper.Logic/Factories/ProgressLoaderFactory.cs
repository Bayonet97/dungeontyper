using DungeonTyper.Common.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Logic.Factories
{
    public class ProgressLoaderFactory : IFactory<IProgressLoader>
    {
        public IProgressLoader Create()
        {
            return new ProgressLoader();
        }
    }
}
