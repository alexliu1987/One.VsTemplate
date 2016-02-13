using System;

namespace $safeprojectname$.Domain.Repositories.Specifications
{
    /// <summary>
    /// 分页信息类
    /// </summary>
    [Serializable]
    public class Pages
    {
        // 默认每页记录数
        private const int RecordsPaginalDefault = 10;

        // 最大排序深度
        private const int SortDepth = 3; 

        // 排序
        // 页码
        private int _pageNumber = 1;

        // 每页记录数
        private int _recordPaginal = RecordsPaginalDefault;
        
        // 总记录数
        private int _recordSum;

        /// <summary>
        /// 创建 Pages 对象实例
        /// </summary>
        public Pages()
        {

        }

        /// <summary>
        /// 获取或设置页码
        /// </summary>
        public int PageNumber
        {
            get { return _pageNumber; }
            set { _pageNumber = value; }
        }

        /// <summary>
        ///     获取或设置每页记录数
        /// </summary>
        public int RecordPaginal
        {
            get { return _recordPaginal; }
            set { _recordPaginal = value; }
        }

        /// <summary>
        ///     获取或设置获取或设置总记录数
        /// </summary>
        public int RecordSum
        {
            get { return _recordSum; }
            set { _recordSum = value; }
        }

        /// <summary>
        ///     获取总页数
        /// </summary>
        public int PageSum
        {
            get
            {
                if (_recordSum % _recordPaginal == 0)
                    return _recordSum / _recordPaginal;
                return _recordSum / _recordPaginal + 1;
            }
        }

        /// <summary>
        ///     获取本页记录数
        /// </summary>
        public int RecordThisPage
        {
            get
            {
                if (_pageNumber == PageSum) // 最后一页
                    return RecordSum - RecordPaginal * (_pageNumber - 1);
                return RecordPaginal;
            }
        }

        /// <summary>
        ///     获取起始记录号
        /// </summary>
        public int First
        {
            get
            {
                return (_pageNumber - 1)*_recordPaginal + 1;
            }
        }

        /// <summary>
        ///     获取终止记录号
        /// </summary>
        public int Last
        {
            get
            {
                if (_recordSum == 0) // 无记录
                    return 0;
                if (_pageNumber == PageSum) // 最后一页
                    return RecordSum;
                return RecordPaginal * _pageNumber;
            }
        }

        /// <summary>
        ///     获取上一页码
        /// </summary>
        public int PrevPage
        {
            get
            {
                return  PageNumber == 1 ? 1 : PageNumber - 1;
            }
        }

        /// <summary>
        ///     获取下一页码
        /// </summary>
        public int NextPage
        {
            get
            {
                return PageNumber == PageSum ? PageSum : PageNumber + 1;
            }
        }

        public string[] SortFields { get; } = new string[SortDepth];

        /// <summary>
        ///     获取排序字符串
        /// </summary>
        public string SortString
        {
            get
            {
                var sortString = "";

                foreach (var field in SortFields)
                {
                    if (!string.IsNullOrEmpty(field))
                    {
                        if (sortString != "")
                            sortString += ",";
                        sortString += field;
                    }
                }
                return sortString;
            }
        }

        /// <summary>
        ///     添加排序属性
        /// </summary>
        /// <param name="field">排序字段</param>
        public void AddSortField(string field)
        {
            if (field == "")
                return;

            if (string.IsNullOrEmpty(SortFields[0])) // 还未有排序规则，直接添加
                SortFields[0] = field + " asc";
            else if (SortFields[0] == field + " asc") // 与第一个排序规则相同，翻转
                SortFields[0] = field + " desc";
            else if (SortFields[0] == field + " desc")
                SortFields[0] = field + " asc";
            else
            {
                // 递推起点
                var start = SortFields.Length - 1;
                for (var i = 0; i < SortFields.Length; i++)
                {
                    // 已有该排序规则
                    if (SortFields[i] == field + " asc" || SortFields[i] == field + " desc")
                    {
                        start = i;
                        break;
                    }
                }

                for (var i = start; i > 0; i--)
                    SortFields[i] = SortFields[i - 1];
                SortFields[0] = field + " asc";
            }
        }

        /// <summary>
        ///     添加逆序属性
        /// </summary>
        /// <param name="field">排序字段</param>
        public void AddConverseField(string field)
        {
            AddSortField(field);
            AddSortField(field);
        }

        /// <summary>
        ///     添加排序属性
        /// </summary>
        /// <param name="field">排序字段</param>
        /// <param name="order">是否按顺序</param>
        public void AddSortField(string field, bool order)
        {
            AddSortField(field);
            if (!order)
                AddSortField(field);
        }

        /// <summary>
        ///     取得排序字段
        /// </summary>
        /// <param name="index">序号</param>
        /// <returns>排序字段</returns>
        public string GetSortString(int index)
        {
            return index >= SortDepth ? "" : SortFields[index];
        }
    }
}