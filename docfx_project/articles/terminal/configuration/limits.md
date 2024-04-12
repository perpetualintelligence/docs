# Limits

## Configuration Options
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
The hosted service will print the following mandatory messsage in the terminal for `demo` licenses.

Education
```
Your demo license is free for educational purposes. For non-educational, release, or production environment, you require a commercial license.
```

RnD
```
Your demo license is free for RnD, test, and evaluation purposes. For release, or production environment, you require a commercial license.
```

Custom
```
Your custom license is free for RnD, test and evaluation purposes. For release, or production environment, you require a commercial license.
```

## Text Handler
Currently text handlers support `left-to-right` Unicode languages. We seek community help to extend the unicode support for `right-to-left` languages.
