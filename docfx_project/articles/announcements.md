# Announcements

## Package Migration

### PerpetualIntelligence.Terminal
The `PerpetualIntelligence.Terminal` Nuget package is obsolete in favor of `OneImlx.Terminal`. Please migrate your terminal applications to use [`OneImlx.Terminal`](https://www.nuget.org/packages/OneImlx.Terminal) Nuget package.

## Known Issues

### First-time Website Load Error

#### Issue Description
Some users may experience an error when loading our websites for the first time, especially when using chromium browsers. This issue is influenced by network speed of your region. We are actively working with Microsoft to find a resolution as quickly as possible.

>Note: This issue does not impact our Nuget package usage, only the website.

#### Impacted Sites
- [Main Website](https://www.perpetualintelligence.com/)
- [Consumer Portal](https://www.consumer.perpetualintelligence.com/)

#### Workaround
If you encounter this issue, try the following steps:
- Refresh the page or perform a hard reload in the same browser tab. You can use:
  - `F5` for a regular refresh.
  - `Ctrl + R` or `Cmd + R` (on Mac) for a hard reload.
  - `Ctrl + Shift + R` or `Cmd + Shift + R` (on Mac) for a hard reload.
- If the problem persists, please report it by creating an issue [here](https://github.com/perpetualintelligence/requests).
