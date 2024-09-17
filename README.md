# Unity Platform Define Switcher

*A tool for managing and switching platform-specific scripting defines in Unity.*

## Introduction

Unity Platform Define Switcher is an editor extension for Unity that allows developers to easily manage and switch between different platform-specific scripting define symbols. This tool simplifies the process of setting up build configurations for multiple platforms by providing a user-friendly interface within the Unity Editor.

## Features

- **Easy Platform Switching**: Switch between predefined platforms with a single click.
- **Customizable Defines**: Add or remove scripting define symbols for each platform.
- **Editor Integration**: Seamlessly integrated into the Unity Editor through a custom window.
- **Supports Multiple Platforms**: Pre-configured for platforms like RU_STORE, YANDEX_GAMES, GOOGLE_PLAY, NASH_STORE, and easily extendable.

## Installation

### Using Unity Package Manager (UPM)

1. Open your Unity project.
2. Navigate to **Window > Package Manager**.
3. Click on the **➕** button and select **"Add package from git URL..."**.
4. Enter the Git URL of the repository:

   ```
   https://github.com/RimuruDev/Unity-PlatformDefineSwitcher.git
   ```

5. Click **Add** to install the package.

### Manual Installation

1. Clone or download the repository from [GitHub](https://github.com/RimuruDev/Unity-PlatformDefineSwitcher).
2. Copy the `Packages/com.rimurudev.platform-define-switcher` folder into your project's `Packages` directory.

## Usage

1. After installation, go to **Platform Build Settings > Platform Build Settings** in the Unity Editor menu.
2. The **Platform Build Settings** window will appear.
3. In the window, you can:

    - View the **Current platform** define.
    - Select a platform from the dropdown menu.

4. Click **Apply** to set the scripting define symbols for the selected platform.
5. The tool will automatically add or remove defines based on your selection.

### Supported Platforms

- **RU_STORE**
- **YANDEX_GAMES**
- **GOOGLE_PLAY**
- **NASH_STORE**

To add more platforms:

1. Open the `BuildPlatform.cs` script located in `Runtime/`.

   ```csharp
   namespace AbyssMoth
   {
       public enum BuildPlatform
       {
           None = 0,
           RU_STORE = 1,
           YANDEX_GAMES = 2,
           GOOGLE_PLAY = 3,
           NASH_STORE = 4,
           // Add your new platforms here :D
           // MY_NEW_PLATFORM = 5,
       }
   }
   ```

2. Add your new platform to the `BuildPlatform` enum.
3. Update the switch cases in `PlatformBuildSettings.cs` to handle the new platform.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.

## Contact

- **Author**: RimuruDev
- **Email**: [rimuru.dev@gmail.com](mailto:rimuru.dev@gmail.com)
- **GitHub**: [https://github.com/RimuruDev](https://github.com/RimuruDev)
- **LinkedIn**: [https://www.linkedin.com/in/rimuru/](https://www.linkedin.com/in/rimuru/)

## Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create your feature branch (`git checkout -b feature/NewFeature`).
3. Commit your changes (`git commit -m 'Add some feature'`).
4. Push to the branch (`git push origin feature/NewFeature`).
5. Open a pull request.

## Support

If you encounter any issues or have questions, please open an [issue](https://github.com/RimuruDev/Unity-PlatformDefineSwitcher/issues) on GitHub.

## Acknowledgments

- Inspired by the need to simplify platform-specific build configurations in Unity projects.
- Thanks to the Unity community for their continuous support and contributions.
