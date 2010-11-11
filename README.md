# mir:lite #
mir:lite is a Mirware replacement for the Violet Mirror done in .NET Windows Forms. It is a true replacement in the sense that there is actually a GUI for the user, as opposed to being just an interfacing library or having only a command line interface. With mir:lite you can very easily configure programs and scripts to run upon mir:ror events without having to rely on Violet's servers. There are also things you can do with mir:lite that you can't achieve with Mirware...

## features ##
- A starightforward, compact interface that is easier and quicker to configure than that of Mirware's
- Doesn't need to be connected to the internet to work
- Configure scripts and programs to run when an object is placed or removed, or when your mir:ror is connected or disconnected
- Enable or disable configured scripts and programs with one click
- Turn off lights and sound to your mir:ror *(refer to caveat below)

### caveats ###
- No built in convenience tasks such as 'Lock my computer' or 'Post ... to Facebook'
- Due to limited understanding of the reverse-engineered mir:ror protocol, turning lights and sound off often requires a physical reconnect of the mir:ror (mir:lite will prompt you when this is required)

## usage/platform compatibility ##
The easiest way to use mir:lite is by downloading the latest msi installer from the Downloads section. Right now mir:lite only works on Windows. However, I've been using .NET features conservatively in the hopes of porting it to Linux and the Mac via Mono (refer to below section for more info)

## TODO/contributions ##
- homepage
- Mono port to Linux/Mac*

*: [libmirror](http://sourceforge.net/projects/libmirror/) is the backend library being used. That in turn uses this [USB library](http://www.codeproject.com/KB/cs/USB_HID.aspx). libmirror's developer has confirmed that some changes need to be made in the way the USB library is being used before the code can be Mono-compatible, and he won't be able to update the project until at least next spring. As such, I would really appreciate if anyone would like to help with this!

## credits ##
Thanks to Juha Luotio and his [libmirror](http://sourceforge.net/projects/libmirror/) project, which serves as the backend for mir:lite.

## help ##
- Source project page:                    http://github.com/suan/mirlite
- Report a bug/Request a feature:         http://github.com/suan/mirlite/issues
- [Give feedback/Contact me (Suan-Aik Yeo)](mailto:yeosuanaik@gmail.com)
