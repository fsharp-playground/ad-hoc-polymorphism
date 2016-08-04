#!/bin/sh

#fsharpc Snippet/SingleModule.Modify.fs
#mono SingleModule.Modify.exe
rm *.exe

fsharpc Snippet/Fmap.Modify.fs
mono Fmap.Modify.exe

fsharpc Snippet/Fmap.fs
mono Fmap.exe

fsharpc Snippet/SingleModule.Update.fs
mono SingleModule.Update.exe

fsharpc Snippet/SingleModule.Original.fs
mono SingleModule.Original.exe