# Using Phi-3 Mini with ONNX as local Small Language Model

![Header](./docs/header.png)

This repository demonstrates how to seamlessly integrate the Phi-3 Mini Model using ONNX in a .NET Console application. By following this guide, you will learn how to set up and use a local Small Language Model to simulate chat interactions.

## Getting Started

Make sure that Git LFS (Large File Storage) is installed by running the following command:

```bash
git lfs install
```

Now, we can clone the model from [Hugging Face](https://huggingface.co/microsoft/Phi-3-mini-128k-instruct).

```bash
git clone https://huggingface.co/microsoft/Phi-3-mini-4k-instruct-onnx
```

In the downloaded folder, you will find a directory named `cpu_and_mobile/cpu-int4-rtn-block-32-acc-level-4`. This directory contains all the necessary files. Be sure to note the path to this folder.

Now, let's run the application.

## Screenshots

First, you need to specify the path to the model folder.

![Console](./docs/console-01.png)

Now, you can start chatting with your local Small Language Model.

![Console](./docs/console-02.png)