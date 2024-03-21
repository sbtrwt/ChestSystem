using ChestSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestSystem.Chest
{
    public class ChestPool : GenericObjectPool<ChestController>
    {
        private ChestModel chestModel;
       

        public ChestPool(ChestModel model)
        {
            this.chestModel = model;
        }

        public ChestController GetChest() => GetItem<ChestController>();

        protected override ChestController CreateItem<T>() => new ChestController(chestModel);
    }
}
