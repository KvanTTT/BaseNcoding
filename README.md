BaseNcoding
===========

There are well-known algorithms for binary data to string encoding exist, such as algorithms with radix of power of 2 (base32, base64) and algorithms with not of power of 2 ([base85](http://en.wikipedia.org/wiki/Ascii85), [base91](http://sourceforge.net/projects/base91/)).

This library implement algorithm for general case, that is custom alphabet can be used (alphabet with custom length). Here is [**BaseNcoding DEMO**](http://kvanttt.github.io/BaseNcoding/).

Idea of developed algorithm based on base85 encoding, except of block size is not constant, but calculated depending on alphabet length.

### Steps of algorithm
 * Calculation of block size in bits and chars.
 * Conversation of input string to byte array (using UTF8 Encoding).
 * Splitting byte array on n-bit groups.
 * Conversation of every group to radix n.
 * Tail bits processing.

For optimal block size calculation following considerations has been used:

![System for щptimal block size calculation](http://habrastorage.org/files/429/57f/bc1/42957fbc17e947fbaaff404dd81694ce.png)

In this system:

* **a** — Length of alphabet **A**.
* **k** — Count of encoding chars.
* **b** — One digit radix base (2 in most cases).
* **n** — Bits count in radix **b** for representation of **k** chars of alphabet **A**.
* **r** — Compression ratio (greater is better).
* **mbc** - Max block bits count.
* **⌊x⌋** — the largest integer not greater than x (floor).
* **⌈x⌉** — the smallest integer not less than x (ceiling).

Diagram of optimal block size and alphabet length dependence has been calculated with help of system above:
![](http://habrastorage.org/getpro/habr/post_images/910/d57/8b8/910d578b87c79d7ca121584e277de221.png)

One can see that known base64, base85, base91 encodings has been developed in good points (minimal block size with good compression ratio).

For bits block to chars block BigNumbers are using.
Algorithm has parallel version.

### License

BaseN algorithm is licensed under the Apache 2.0 License.

More detail explanation available [on Russian](http://habrahabr.ru/post/219993/).
