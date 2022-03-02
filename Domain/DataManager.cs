
using project.Domain.Entities;
using project.Domain.Entities.Review;
using project.Domain.Repositories.Abstract;

namespace project.Domain;

public class DataManager
{
    public IRepository<UserAccount> UserAccounts { get; private set; }
    public IRepository<UserReview> UserReviews { get; private set; }
    public IRepository<Comment> Comments { get; private set; }
    public IRepository<Group> Groups { get; private set; }
    public IRepository<HashTag> HashTags { get; private set; }
    public IRepository<Image> Images { get; private set; }
    public IRepository<Like> Likes { get; private set; }

    public DataManager(IRepository<UserAccount> userAccounts,IRepository<UserReview> userReviews, 
                       IRepository<Comment> comments, IRepository<Group> groups, IRepository<HashTag> hashTags,
                       IRepository<Image> images, IRepository<Like> likes)
    {
        UserAccounts = userAccounts;
        UserReviews = userReviews;
        Comments = comments;
        Groups = groups;
        HashTags = hashTags;
        Images = images;
        Likes = likes;
    }
}