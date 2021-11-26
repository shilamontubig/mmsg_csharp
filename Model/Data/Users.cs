using System.Collections.Generic;

namespace Model.Data {

    public record UsersData(
        int page,
        int per_page,
        int total_pages,
        int total,
        IList<User> Data
    ){}
}
