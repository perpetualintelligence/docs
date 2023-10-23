# Defaults and Limits

`pi-cli` defaults to following values and configuration restrictions to avoid parsing and performance bottlenecks.

## Regex

The following regex patterns are used while parsing command strings. Application authors can customize and define their parsing logic.

### Static Regex Patterns (Commands)

- `^[A-Za-z0-9_-]*$`

### Dynamic Regex Patterns (Arguments)

- `^[ ]*(-)+(.+?)[ ]*$`
- `^[ ]*(-)+(.+?)=+(.*?)[ ]*$`
- `^[ ]*(-)+(.+?)[ ]*$`
- `^[ ]*(-)+(.+?)=+(.*?)[ ]*$`
- `^(.*)$`
 
## Restrictions

### Configuration Options

The following restrictions apply to the configuration options while parsing the command strings.

- The command separator cannot be `null` or empty string
- The command separator and argument prefix cannot be same
- The command separator and argument alias prefix cannot be same
- The argument separator cannot be `null` or empty string
- The argument prefix cannot be `null` or whitespace
- The argument prefix cannot be more than `3` Unicode characters
- The argument alias prefix cannot be `null` or whitespace
- The argument alias prefix cannot be more than `3` Unicode characters
- The argument separator and argument prefix cannot be same
- The argument separator and argument alias prefix cannot be same
- The argument alias prefix cannot start with argument prefix
- The string with_in token cannot be whitespace
- The string with_in token and separator cannot be same
- The string with_in token and argument prefix cannot be same
- The string with_in token and argument separator cannot be same


## Licensing

The `pi-cli` hosted service will print the following mandatory messsage in the terminal for `community` and `demo` licenses.

### Community Education
```
Your community license plan is free for educational purposes. For non-educational or production environment, you require a commercial license.
```

### Community RnD
```
Your community license plan is free for RnD, test, and demo purposes. For production environment, you require a commercial license.
```

### Demo
```
Your demo license is free for RnD, test and evaluation purposes. For production environment, you require a commercial license.
```

## Text Handler

Currently text handlers only support `left-to-right` Unicode languages.
