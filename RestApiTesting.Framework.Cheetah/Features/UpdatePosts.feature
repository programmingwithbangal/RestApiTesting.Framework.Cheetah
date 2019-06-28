Feature: UpdatePosts
As a non-authenticated user,
I want the ability to update a post.

  Background: 
    Given I have a client "client1"
  
  @AcceptanceCriteria
  Scenario: A non-authenticated user successfully updates a post
    Given I have a string "updated title" named "title1"
      And I have a string "updated body" named "body1"
      And I have an int "1" named "one"
      And I have a model "updatePostsModel1" with the following values:
      | Field  | Value  | 
      | userId | one    | 
      | title  | title1 | 
      | body   | body1  | 
     When I send a "Put" request to "/posts/1" with model "updatePostsModel1" using client "client1" and get the response "updatePostsResponse1"
      And I get the content "updatePostsResponse1Body" of the response "updatePostsResponse1"
     Then the response "updatePostsResponse1" should have the status code "OK"
      And the model "updatePostsResponse1Body" should match the following values:
      | Field  | Value  | 
      | userId | one    | 
      | id     | one    | 
      | title  | title1 | 
      | body   | body1  | 
  
  @NegativePath
  Scenario: A non-authenticated user attempts to update a post with nonexistent id
    Given I have a string "updated title" named "title1"
      And I have a string "updated body" named "body1"
      And I have an int "1" named "one"
      And I have a model "updatePostsModel1" with the following values:
      | Field  | Value  | 
      | userId | one    | 
      | title  | title1 | 
      | body   | body1  | 
     When I send a "Put" request to "/posts/101" with model "updatePostsModel1" using client "client1" and get the response "updatePostsResponse1"
     Then the response "updatePostsResponse1" should have the status code "Internal Server Error"