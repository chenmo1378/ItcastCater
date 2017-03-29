using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItcastCater.Model
{
   public class R_OrderInfo_Product
    {
        #region Model
        //proName,ProUnit,UnitCount,ProPrice,ProPrice*UnitCount,CatName,R_OrderInfo_Product.SubTime

        public int CT { get; set; }
        public decimal MONEY { get; set; }
        #region 冗余属性
        private string _proName;//商品名字
        /// <summary>
        /// 商品的名字
        /// </summary>
        public string ProName
        {
            get { return _proName; }
            set { _proName = value; }
        }
        private string _proUnit;//商品单位
        /// <summary>
        /// 商品的单位
        /// </summary>
        public string ProUnit
        {
            get { return _proUnit; }
            set { _proUnit = value; }
        }
        private decimal? _proPrice;//商品单价
        /// <summary>
        /// 商品的单价
        /// </summary>
        public decimal? ProPrice
        {
            get { return _proPrice; }
            set { _proPrice = value; }
        }
        private string _catName;//商品类型
        /// <summary>
        /// 商品的类别
        /// </summary>
        public string CatName
        {
            get { return _catName; }
            set { _catName = value; }
        }
        private decimal? _ProMoney;
        /// <summary>
        /// 商品的总价
        /// </summary>
        public decimal? ProMoney
        {
            get { return _ProMoney; }
            set { _ProMoney = value; }
        }
        #endregion
        private int _rorderproid;
        private int? _orderid;
        private int _proid;
        private int? _delflag;
        private DateTime? _subtime;
        private int? _state;
        private decimal? _unitcount;
        /// <summary>
        /// 表连接主键
        /// </summary>
        public int ROrderProId
        {
            set { _rorderproid = value; }
            get { return _rorderproid; }
        }
        /// <summary>
        /// 订单主键
        /// </summary>
        public int? OrderId
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 商品主键
        /// </summary>
        public int ProId
        {
            set { _proid = value; }
            get { return _proid; }
        }
        /// <summary>
        /// 删除标识
        /// </summary>
        public int? DelFlag
        {
            set { _delflag = value; }
            get { return _delflag; }
        }
        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime? SubTime
        {
            set { _subtime = value; }
            get { return _subtime; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public int? State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal? UnitCount
        {
            set { _unitcount = value; }
            get { return _unitcount; }
        }
        #endregion Model
    }
}
