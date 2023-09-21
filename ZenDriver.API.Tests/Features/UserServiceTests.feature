Feature: UserServiceTests
As a Developer
I want to add new User through API
In order to make it available for applications.

    Background:
        Given the Endpoint https://localhost:7275/api/v1/users is available

    @tutorial-adding
    Scenario: Add User with unique Username
        When a Post Request is sent
          | FirstName | LastName | Username         | Password   | Phone     | Role   | Description   |
          | Abel      | Cierto   | cierto@gmail.com | AbelCierto | 993293832 | driver | I am a driver |
        Then A Response is received with Status 200
        And a User Resource is included in Response Body
          | Id | FirstName | LastName | Username         | Password   | Phone     | Role   | Description   |
          |  1 | Abel      | Cierto   | cierto@gmail.com | AbelCierto | 993293832 | driver | I am a driver |