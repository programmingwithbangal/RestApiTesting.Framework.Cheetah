Feature: PatchPosts
As a non-authenticated user,
I want the ability to patch a post.

  Background: 
    Given I have a client "client1"
  
  @AcceptanceCriteria
  Scenario: A non-authenticated user successfully patchs a post
    Given I have a string "patched body" named "body1"
      And I have a model "patchPostsModel1" with the following values:
      | Field | Value | 
      | body  | body1 | 
      And I have an int "1" named "one"
      And I have a string "sunt aut facere repellat provident occaecati excepturi optio reprehenderit" named "titleActual"
     When I send a "Patch" request to "/posts/1" with model "patchPostsModel1" using client "client1" and get the response "patchPostsResponse1"
      And I get the content "patchPostsResponse1Body" of the response "patchPostsResponse1"
     Then the response "patchPostsResponse1" should have the status code "OK"
      And the model "patchPostsResponse1Body" should match the following values:
      | Field  | Value       | 
      | userId | one         | 
      | id     | one         | 
      | title  | titleActual | 
      | body   | body1       | 
  
  @NegativePath
  Scenario: A non-authenticated user attempts to patch a post with nonexistent id
    Given I have a string "patched body" named "body1"
      And I have a model "patchPostsModel1" with the following values:
      | Field | Value | 
      | body  | body1 | 
     When I send a "Patch" request to "/posts/101" with model "patchPostsModel1" using client "client1" and get the response "patchPostsResponse1"
      And I get the content "patchPostsResponse1Body" of the response "patchPostsResponse1"
     Then the response "patchPostsResponse1" should have the status code "OK"
      And the model "patchPostsResponse1Body" should match the following values:
      | Field | Value | 
      | body  | body1 |