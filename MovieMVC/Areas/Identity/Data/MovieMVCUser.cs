using Microsoft.AspNetCore.Identity;
using MovieMVC.Models;

namespace MovieMVC.Areas.Identity.Data;

// Add profile data for application users by adding properties to the MovieMVCUser class
public class MovieMVCUser : IdentityUser
{
    //public string Alias { get; set; }  //I added this line to be able to have an alias on userprofile. 
    public List<Post> Posts { get; set; }

}

