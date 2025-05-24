# Maintainer: bozidarsk <aaaa@gmail.com>
name='whiteboard-gtkwebview'
pkgname="$name-git"
pkgver=1
pkgrel=1
pkgdesc="GtkSharp WebView for microsoft whiteboard."
arch=('x86_64')
url="https://github.com/bozidarsk/$name"
license=('unknown')
depends=('dotnet-runtime' 'webkit2gtk')
makedepends=('dotnet-sdk')

# to update version
# makepkg --printsrcinfo > .SRCINFO

prepare() 
{
	git clone "$url.git" --recurse-submodules "$srcdir/$name"
}

build() 
{
	cd "$srcdir/$name"
	dotnet publish -r linux-x64 -c Release
}

package() 
{
	install -vDm755 "$srcdir/$name/bin/Release/*/linux-x64/publish/whiteboard-gtkwebview" -t "$pkgdir/usr/bin/"
	install -vDm644 "$srcdir/$name/Whiteboard.desktop" -t "$pkgdir/usr/share/applications/"
}
