# ChromaImporter

Prototype importer for Chroma ATE Access DB (`.mdb`) files.

## Status

`in-development` — this is a standalone console prototype. **Converter Host Plugin refactor is deferred.**

## What it does

Connects to a Chroma ATE `.mdb` database using `Microsoft.Jet.OLEDB.4.0`, reads the `HeadInfoSet` table, and prints rows to stdout.

## Limitations

- Requires 32-bit process (`x86` target).
- Requires `.NET Framework 4.8` — `Jet.OLEDB.4.0` is not available on .NET Core/.NET 5+.
- Does **not** yet produce WATS UUT reports. Full converter integration is a future task.

## Usage

```
ChromaImporter.exe [path-to-file.mdb]
```

If no argument is given, falls back to `Data\chroma-sample.mdb`.

## Future work

- Replace `Jet.OLEDB.4.0` with a cross-platform MDB reader library or migrate to WATS Converter Host Plugin pattern.
- Implement full UUT report mapping from `HeadInfoSet` and related tables.
