using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestToolkit.model
{
    public class ErrorContent
    {
        public static String ERROR_EMPTY = "Dữ liệu dầu vào bị thiếu! vui lòng bổ sung thêm!";
        public static String ERROR_ZERO_LENGTH = "Danh sách bị trống vui lòng thêm dữ liệu vào danh sách";
        public static String ERROR_JSON_FORMAT = "Không đúng định dạng JSON vui lòng kiểm tra lại";
        public static String ERROR_REUQEST_NULL = "Request thất bại vui lòng kiểm tra dữ liệu đầu vào";
        public static String ERROR_CONTENT_TYPE_NO_MATCH = "Không tìm thấy content type này vui lòng thử lại";
    }
}
