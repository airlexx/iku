# Contributing to iku

Thank you for your interest in *iku*'s development. Here you will find a few guidelines to help you get started.

## Table of contents

1. [Commit formats](#commit-formats)
2. [Questions](#questions)

## Commit formats

<pre>
<b><a href="#types">&lt;type&gt;</a></b></font>(<b><a href="#scopes">&lt;optional scope&gt;</a></b>): <b><a href="#subject">&lt;subject&gt;</a></b>
<sub>empty separator line</sub>
<b><a href="#body">&lt;optional body&gt;</a></b>
<sub>empty separator line</sub>
<b><a href="#footer">&lt;optional footer&gt;</a></b>
</pre>

### Types

- `build:` affect the build system or external dependencies
- `ci:` changes to integration or configuration files and scripts
- `docs:` only affects the documentation
- `feat:` adds a new feature
- `fix:` fixes a bug
- `perf:` improves performance
- `refactor:` restructures the code without changing the behavior
- `style:` does not affect the meaning
- `test:` adds missing tests or correcting existing tests

### Scopes

The `scope` provides additional contextual information.

- Is an **optional** part of the format
- Scopes depends on the specific project
- Do not use issue identifiers as scopes

### Subject

The `subject` contains a short description of the change.

- Is a **mandatory** part of the format
- Use the present imperative
- Do not capitalize the first letter
- No dot (.) at the end

### Body

The `body` should include the motivation for the change and contrast this with previous behavior.

- Is an **optional** part of the format
- Use the present imperative
- This is the place to mention issue identifiers and their relations

### Footer

The `footer` should contain any information about **Breaking Changes** and is also the place to **reference Issues** that this commit refers to.

- Is an **optional** part of the format
- **optionally** reference an issue by its id.
- **Breaking Changes** should start with the word `BREAKING CHANGES:` followed by space. The rest of the commit message is then used for this.

## Questions

If you have any questions, comments or issues regarding iku. Please let us know on [Discord](https://discord.gg/8VUSBu97zv), we will be happy to assist you.