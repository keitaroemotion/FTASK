# ftask

TODO managing tool code in F#


## installation 

The command below does whole installation, which is

1) build the entire ftask repository
2) make directories required for the installation
3) copy exection binary (at this point only for MacOSX) to /usr/local/bin
   and ~/.ftask such that callable from anywhere.

```
$ ./scripts/run
```

## usage

```
$ ftask
```

## analysis

```
$ ./scripts/sqldoc
```

then you can see the content of sqlite database, located at /usr/local/etc/ftask/todo.sqlite
