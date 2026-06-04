# Contributing to Monotect

Contributions are welcome in the form of **issues** and **pull requests**.

You can [submit an issue](https://github.com/ben-cassidy/Monotect/issues/new) to report a bug, request a new feature, suggest a performance improvement, or request better documentation or support on a particular issue.

To contribute code, you need to [fork this repository](https://github.com/ben-cassidy/Monotect/fork), create a feature branch on your fork, then open a pull request using the 'Contribute' button in your fork's homepage.

## Code Standards

### Style

In general, the style that the [.NET project uses](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions) applies. The granular style specifications can be found in the [.editorconfig](.editorconfig) file.

### Memory Safety

Whilst C# is a beautifully safe language on the surface, this library is heavily dependent on manual pointer arithmetic. Any changes to `unsafe` blocks of code should be analysed and tested with extra rigour.

## Use of Generative AI

As a rule, **do not** commit a line of code that wasn't, at the very least, typed (and understood) by a human. Use of AI agents, as well as directly copy-pasting code from an AI chatbot, is not allowed due to the abundance of `unsafe` code.

It is permissible to consult AI assistants, including Copilot, or to have them check your solution or code. However, you should take care to double-check all AI-generated solutions, and ensure you *retype* its output rather than simply pasting it in. This is a self-policed policy to encourage understanding each line of code before you commit.

**If you have Copilot (or another AI assistant) enabled in your IDE, please:**
- Disable inline suggestions.
- Ensure all chats are in 'Ask' mode, to prevent the LLM making direct changes.
