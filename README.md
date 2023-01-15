# WizTreeTools

Tiny tools for WizTree. (As you can see, there is only one tiny tool.)

## CalUsedFileSize

A tool for calculating actual total file used size with WizTree CSV data.

You can use this tool with double parmeter as the path of WirTree CSV data and cluster size of storage.
```
$> CalUsedFileSize /path/to/WirTreeData.csv 4096
```
Or just input them after you start it.
```
$> CalUsedFileSize
WizTree CSV file path = /path/to/WirTreeData.csv
Cluster size of storage = 4096
```

### Third Part

* [CsvHelper](https://joshclose.github.io/CsvHelper/) with [Apache License 2.0](https://licenses.nuget.org/Apache-2.0).

* [Steveo.FileSizen](https://github.com/StevePotter/FileSize) with [MIT License](http://www.opensource.org/licenses/mit-license.php).

---

View repository on [GitHub](https://github.com/Orange23333/WizTreeTools).