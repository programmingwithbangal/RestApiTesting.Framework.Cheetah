Feature: GetPosts
As a non-authenticated user,
I want the ability to get a post.

  Background: 
    Given I have a client "client1"
  
  @AcceptanceCriteria
  Scenario: A non-authenticated user successfully gets a post
    Given I have a string "sunt aut facere repellat provident occaecati excepturi optio reprehenderit" named "title1"
      And I have a string "quia et suscipit suscipit recusandae consequuntur expedita et cum reprehenderit molestiae ut ut quas totam nostrum rerum est autem sunt rem eveniet architecto" named "body1"
      And I have an int "1" named "one"
     When I send a "Get" request to "/posts/1" using client "client1" and get the response "deletePostsResponse1"
      And I get the content "deletePostsResponse1Body" of the response "deletePostsResponse1"
     Then the response "deletePostsResponse1" should have the status code "OK"
      And the "userId" of "deletePostsResponse1Body" should be "one"
      And the "id" of "deletePostsResponse1Body" should be "one"
      And the "title" of "deletePostsResponse1Body" should be "title1"
      And I compare "body" of "deletePostsResponse1Body" with "body1"
      And the modified "body" of "deletePostsResponse1Body" should be modified "body1"
  
  @NegativePath
  Scenario: A non-authenticated user attempts to get a post with nonexistent id
     When I send a "Get" request to "/posts/101" using client "client1" and get the response "deletePostsResponse1"
      And I get the content "deletePostsResponse1Body" of the response "deletePostsResponse1"
     Then the response "deletePostsResponse1" should have the status code "Not Found"