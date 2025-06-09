# Valocity Technical Assessment

This assessment is designed to emulate a day in the life of a Valocity Software 
Engineer. You will be assessed on how well you follow instructions and express the 
intent of your changes using the tools at hand. It's purpose is not to trick
you or catch you out but to get an understanding of how you think about solving
problems using software and capturing learnings and intent using nothing but files 
within a version control system.

Take as much or as little time as you like, however we suggest around
**90 minutes** to get through as much as you can. It is up to you to manage your time. The answers will be assessed against the
role you have applied for so ensure you demonstrate the key objectives expected
by the role.

**Commit** to the local git repo **often** to show progress and workflow. Ensure
the commit comments explain **why** you did the change.


## Getting started

You will need [git](https://git-scm.com/) and a code editor of your choice.

## Submitting

To submit your solution:

 1. Ensure you have committed all your changes
 2. Run `git clean -xdf` to clear our any build artifacts
    - > ⚠ **Binary files** in the submission will be **blocked** by spam filters
 3. Compress the solution source into a single archive
    - > ⚠ Ensure the **.git** folder and **other hidden** files are **included** in the archive
 4. Send on through to [a4140646.valocity.com.au@apac.teams.ms](mailto:a4140646.valocity.com.au@apac.teams.ms?subject=Technical%20assessment)!

## Assessment

### Exercise 1: Code Review

The code in [CodeToReview.cs](CodeToReview.cs) has been submitted by an intern
from another team to a code base you depend on. Using inline comments, review
the code with either questions for clarification or feedback with enough context 
for the author to learn and enhance the code.

### Exercise 2: Working with legacy code

This will asses your ability to work safely with existing code. Use tests to gain an understanding of the existing behaviours and ensuring your changes are safe. Your task is to refactor [CodeToRefactor.cs](./ReFactor/CodeToRefactor.cs). Use comments, commit messages and automated tests to express your reasoning, assumptions and issues encountered.

### Exercise 3: Clean green fields project

This will asses your

- Ability to design solutions
- Ability to decompose problems
- Knowledge of clean architecture
- Knowledge of continuous delivery and devops
- Ability to identify constraints and assumptions
- Awareness of cognitive biases
- Test driven development skills

> **As** an enthusiastic card player and developer </br>
> **I want to** create a program to play cards against the computer </br>
> **So that** when I am bored I can play against an intelligent opponent.

#### Constraints

Unsure of what UI to build for, or what card game I should code for. We will figure that out later. At this stage I know I need a concept of a Deck, Cards and a Shuffle function.

How would you setup your new solution and why?

- Show me your initial to do list with some reasoning, for example:
  - Development environment setup
  - Scaffold / structure of your solution
  - What would your delivery pipeline look like
- Scaffold your solution
  - See how much you can scaffold out to hand to another team member to continue with
  - Bonus points if you have something working