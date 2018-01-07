using System;

public class Program
{
    public static void Main()
    {

        // Create a blog using one of the contructor
        Blog myBlog = new Blog("I am learning C#");

        myBlog.Description = "This is the content of the blog.";
        myBlog.Created = DateTime.Now;

        //voting
        myBlog.IncrementDownvote();
        myBlog.IncrementUpvote();
        myBlog.IncrementUpvote();
        
        Console.WriteLine(myBlog.Title);
        Console.WriteLine(myBlog.Description);
        Console.WriteLine(myBlog.CreatedOn);
        Console.WriteLine(myBlog.Upvote);
        Console.WriteLine(myBlog.Downvote);

        Console.ReadLine();
    }
}

public class Blog
{
    // Field
    public string Title;
    public string Description;
    public DateTime Created;

    // Non public field
    // avoid having them set to 0
    private int _upvote;
    private int _downvote;

    // Constructor  // Blog myBlog = new Blog();
    public Blog()
    {
        _upvote = 0;
        _downvote = 0;
    }

    // Constructor overload
    public Blog(string title)
    {
        Title = title;
    }

    // Properties 
    public string Upvote
    {
        get
        {
            return $"upvotes {_upvote}";
        }
        set
        {
            if (int.Parse(value) > 0)
                _upvote = int.Parse(value);
        }
    }

    public string Downvote
    {
        get
        {
            return $"downvotes {_downvote}";
        }
    }

    public string CreatedOn
    {
        get
        {
            return "Created on " + string.Format("{0:MMM/dd/yy}", Created);
        }
    }

    // Methods 
    public void IncrementUpvote()
    {
        _upvote++; //_upvote = _upvote + 1;
    }

    public void IncrementDownvote()
    {
        _downvote++;
    }
}