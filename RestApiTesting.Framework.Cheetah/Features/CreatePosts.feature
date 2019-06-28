Feature: CreatePosts
As a non-authenticated user,
I want the ability to create a post.

  Background: 
    Given I have a client "client1"
  
  @AcceptanceCriteria
  Scenario: A non-authenticated user successfully creates a post
    Given I have a string "title" named "title1"
      And I have a string "str body" named "body1"
      And I have an int "1" named "userId1"
      And I have an int "101" named "id1"
      And I have a model "createPostsModel1" with the following values:
      | Field  | Value   | 
      | userId | userId1 | 
      | id     | id1     | 
      | title  | title1  | 
      | body   | body1   | 
     When I send a "Post" request to "/posts" with model "createPostsModel1" using client "client1" and get the response "createPostsResponse1"
      And I get the content "createPostsResponse1Body" of the response "createPostsResponse1"
     Then the response "createPostsResponse1" should have the status code "Created"
      And the model "createPostsResponse1Body" should have 4 parameters
      And the model "createPostsResponse1Body" should match the following values:
      | Field  | Value   | 
      | userId | userId1 | 
      | id     | id1     | 
      | title  | title1  | 
      | body   | body1   | 