namespace Model.Data {
  
    public record UserDetails(
        int Id,
        string Email,
        string First_Name,
        string Last_Name,
        string Avatar
    ){}
    public record User(
            UserDetails data
    ){}

    public record JobDetails(
            string name,
            string job, 
            string id, 
            string created_at
    ){}

    public record UserAccount(
            string email,
            string password,
            string id, 
            string token, 
            string error
    ){}

}