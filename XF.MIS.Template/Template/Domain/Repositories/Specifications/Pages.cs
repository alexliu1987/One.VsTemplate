using System;

namespace $safeprojectname$.Domain.Repositories.Specifications
{
    /// <summary>
    /// ��ҳ��Ϣ��
    /// </summary>
    [Serializable]
    public class Pages
    {
        // Ĭ��ÿҳ��¼��
        private const int RecordsPaginalDefault = 10;

        // ����������
        private const int SortDepth = 3; 

        // ����
        // ҳ��
        private int _pageNumber = 1;

        // ÿҳ��¼��
        private int _recordPaginal = RecordsPaginalDefault;
        
        // �ܼ�¼��
        private int _recordSum;

        /// <summary>
        /// ���� Pages ����ʵ��
        /// </summary>
        public Pages()
        {

        }

        /// <summary>
        /// ��ȡ������ҳ��
        /// </summary>
        public int PageNumber
        {
            get { return _pageNumber; }
            set { _pageNumber = value; }
        }

        /// <summary>
        ///     ��ȡ������ÿҳ��¼��
        /// </summary>
        public int RecordPaginal
        {
            get { return _recordPaginal; }
            set { _recordPaginal = value; }
        }

        /// <summary>
        ///     ��ȡ�����û�ȡ�������ܼ�¼��
        /// </summary>
        public int RecordSum
        {
            get { return _recordSum; }
            set { _recordSum = value; }
        }

        /// <summary>
        ///     ��ȡ��ҳ��
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
        ///     ��ȡ��ҳ��¼��
        /// </summary>
        public int RecordThisPage
        {
            get
            {
                if (_pageNumber == PageSum) // ���һҳ
                    return RecordSum - RecordPaginal * (_pageNumber - 1);
                return RecordPaginal;
            }
        }

        /// <summary>
        ///     ��ȡ��ʼ��¼��
        /// </summary>
        public int First
        {
            get
            {
                return (_pageNumber - 1)*_recordPaginal + 1;
            }
        }

        /// <summary>
        ///     ��ȡ��ֹ��¼��
        /// </summary>
        public int Last
        {
            get
            {
                if (_recordSum == 0) // �޼�¼
                    return 0;
                if (_pageNumber == PageSum) // ���һҳ
                    return RecordSum;
                return RecordPaginal * _pageNumber;
            }
        }

        /// <summary>
        ///     ��ȡ��һҳ��
        /// </summary>
        public int PrevPage
        {
            get
            {
                return  PageNumber == 1 ? 1 : PageNumber - 1;
            }
        }

        /// <summary>
        ///     ��ȡ��һҳ��
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
        ///     ��ȡ�����ַ���
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
        ///     �����������
        /// </summary>
        /// <param name="field">�����ֶ�</param>
        public void AddSortField(string field)
        {
            if (field == "")
                return;

            if (string.IsNullOrEmpty(SortFields[0])) // ��δ���������ֱ�����
                SortFields[0] = field + " asc";
            else if (SortFields[0] == field + " asc") // ���һ�����������ͬ����ת
                SortFields[0] = field + " desc";
            else if (SortFields[0] == field + " desc")
                SortFields[0] = field + " asc";
            else
            {
                // �������
                var start = SortFields.Length - 1;
                for (var i = 0; i < SortFields.Length; i++)
                {
                    // ���и��������
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
        ///     �����������
        /// </summary>
        /// <param name="field">�����ֶ�</param>
        public void AddConverseField(string field)
        {
            AddSortField(field);
            AddSortField(field);
        }

        /// <summary>
        ///     �����������
        /// </summary>
        /// <param name="field">�����ֶ�</param>
        /// <param name="order">�Ƿ�˳��</param>
        public void AddSortField(string field, bool order)
        {
            AddSortField(field);
            if (!order)
                AddSortField(field);
        }

        /// <summary>
        ///     ȡ�������ֶ�
        /// </summary>
        /// <param name="index">���</param>
        /// <returns>�����ֶ�</returns>
        public string GetSortString(int index)
        {
            return index >= SortDepth ? "" : SortFields[index];
        }
    }
}