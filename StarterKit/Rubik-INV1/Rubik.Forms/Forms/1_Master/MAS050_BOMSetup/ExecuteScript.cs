using EVOFramework.Data;
using Rubik.DTO;
using Rubik.BIZ;
using EVOFramework;

namespace Rubik.Master
{
    partial class MAS050_BOMSetup
    {
        private class InsertSqlExecute : SqlExecute
        {
            public InsertSqlExecute(BOMDTO dto)
            {
                Data = dto;
            }

            public BOMDTO Data { get; set; }

            /// <summary>
            /// Execute operation.
            /// </summary>
            public override void Execute()
            {
                base.Execute();

                BOMBIZ biz = new BOMBIZ();
                biz.AddNew(Data);
            }
        }

        private class UpdateSqlExecute : SqlExecute
        {
            public UpdateSqlExecute(BOMDTO data, NZString oldUpperItemCode, NZString oldLowerItemCode)
            {
                Data = data;
                OldUpperItemCode = oldUpperItemCode;
                OldLowerItemCode = oldLowerItemCode;
            }

            public BOMDTO Data { get; set; }
            public NZString OldUpperItemCode { get; set; }
            public NZString OldLowerItemCode { get; set; }
            /// <summary>
            /// Execute operation.
            /// </summary>
            public override void Execute()
            {
                base.Execute();

                BOMBIZ biz = new BOMBIZ();
                //biz.UpdateWithPK(Data, OldUpperItemCode, OldLowerItemCode);
            }
        }

        private class DeleteSqlExecute : SqlExecute
        {
            public DeleteSqlExecute(BOMDTO data)
            {
                Data = data;
            }
            public BOMDTO Data { get; set; }
            /// <summary>
            /// Execute operation.
            /// </summary>
            public override void Execute()
            {
                base.Execute();

                BOMBIZ biz = new BOMBIZ();
                biz.Delete(Data);
            }
        }
    }
}
