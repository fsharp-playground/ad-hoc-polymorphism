#!/bin/sh

fsharpc Snippet/SingleModule.fs
mono SingleModule.exe

fsharpc Snippet/SingleModule.Original.fs
mono SingleModule.Original.exe