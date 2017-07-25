# Pi
Libraries for use with the Raspberry Pi

## Instructions

These instructions are for .NET Core 2.0. In order to use it with Visual Studio, you need at least Visual Studio 2017 Update 3.

- Clone the repo
- `dotnet publish -r linux-arm` from the root of the repo.
- Copy the contents of the publish folder underneath `bin\Debug\netcoreapp2.0\linux-arm\publish\` to the Raspberry Pi.
- Install the pre-reqs. 
    - Example on Raspbian `sudo apt-get install libc6 libcurl3 libgcc1 libgssapi-krb5-2 libicu-dev liblttng-ust0 libssl-dev libstdc++6 libunwind8 libuuid1 zlib1g`
- `chmod +x IotSample` on the IotSample file in the root of the app.
- `sudo ./IotSample`

Note: Make sure you have enabled GPIO and SPI. You can do this by running `raspi-config` on the Pi.

This project was created based on the [raspberry-sharp](https://github.com/raspberry-sharp) project. This was initially forked off to make it easier to consume it in more places than Mono as well as add Raspberry Pi 3 support.
