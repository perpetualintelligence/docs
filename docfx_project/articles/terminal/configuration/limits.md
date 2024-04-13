# Limits

## Configuration Options
The following restrictions apply to the configuration options while parsing the command strings.
- The command separator cannot be `null` or empty string
- The command separator and option prefix cannot be same
- The command separator and option alias prefix cannot be same
- The option separator cannot be `null` or empty string
- The option prefix cannot be `null` or whitespace
- The option prefix cannot be more than `3` Unicode characters
- The option alias prefix cannot be `null` or whitespace
- The option alias prefix cannot be more than `3` Unicode characters
- The option separator and option prefix cannot be same
- The option separator and option alias prefix cannot be same
- The option alias prefix cannot start with option prefix
- The string with_in token cannot be whitespace
- The string with_in token and separator cannot be same
- The string with_in token and option prefix cannot be same
- The string with_in token and option separator cannot be same


## Licensing
The hosted service will print the following mandatory messsage in the terminal for `demo` licenses.

Education
```
The demo license is free for educational purposes, but non-educational use requires a commercial license.
```

RnD
```
The demo license is free for research and development, but production use requires a commercial license.
```

## Cross-Platform
While the `OneImlx.Terminal` framework is designed to be cross-platform, it's important to note that specific integration libraries, especially those that are hardware-centric or leverage particular messaging systems, may have optimized support for Linux-based OS. Developers should consider these platform-specific characteristics when integrating third-party libraries or services, ensuring comprehensive compatibility and performance across all targeted platforms.


