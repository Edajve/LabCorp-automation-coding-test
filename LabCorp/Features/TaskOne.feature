Feature: Lab Corp Coding Test

    Background:
        Given user is on Lab Corp website

    Scenario: First Assignment
        Given user navigates to career page
        Then user searches for "Sr. Business Analyst" Career position
        Then user returns back to list of applications