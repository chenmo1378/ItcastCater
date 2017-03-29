using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItcastCater.Model
{
    /// <summary>
    /// 订单表
    /// </summary>
    public class OrderInfo
    {

        #region Model
        private int _orderid;
        private DateTime? _subtime;
        private string _remark;
        private int? _orderstate;
        private int? _ordermemid;
        private int? _delflag;
        private int? _subby;
        private DateTime? _begintime;
        private DateTime? _endtime;
        private decimal? _ordermoney;
        private decimal? _discount;
        /// <summary>
        /// 订单主键
        /// </summary>
        public int OrderId
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 订单提交时间
        /// </summary>
        public DateTime? SubTime
        {
            set { _subtime = value; }
            get { return _subtime; }
        }
        /// <summary>
        /// 订单备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int? OrderState
        {
            set { _orderstate = value; }
            get { return _orderstate; }
        }
        /// <summary>
        /// 订单会员编号
        /// </summary>
        public int? OrderMemId
        {
            set { _ordermemid = value; }
            get { return _ordermemid; }
        }
        /// <summary>
        /// 订单删除标识
        /// </summary>
        public int? DelFlag
        {
            set { _delflag = value; }
            get { return _delflag; }
        }
        /// <summary>
        /// 订单提交人
        /// </summary>
        public int? SubBy
        {
            set { _subby = value; }
            get { return _subby; }
        }
        /// <summary>
        /// 订单开始时间
        /// </summary>
        public DateTime? BeginTime
        {
            set { _begintime = value; }
            get { return _begintime; }
        }
        /// <summary>
        /// 订单结束时间
        /// </summary>
        public DateTime? EndTime
        {
            set { _endtime = value; }
            get { return _endtime; }
        }
        /// <summary>
        /// 订单消费总金额
        /// </summary>
        public decimal? OrderMoney
        {
            set { _ordermoney = value; }
            get { return _ordermoney; }
        }
        /// <summary>
        /// 打折
        /// </summary>
        public decimal? DisCount
        {
            set { _discount = value; }
            get { return _discount; }
        }
        #endregion Model
    }
}
