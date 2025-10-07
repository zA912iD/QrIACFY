// 代码生成时间: 2025-10-08 01:54:22
using System;
using System.Windows;
using Microsoft.ML;
using Microsoft.ML.Data;

// 定义数据模型
public class ModelInput
{
    [LoadColumn(0)]
    public float Feature1 { get; set; }

    [LoadColumn(1)]
    public float Feature2 { get; set; }

    // ... 可以根据需要添加更多特征

    [LoadColumn(2)]
    public bool Label { get; set; }
}

public partial class MainWindow : Window
{
    private readonly MLContext _mlContext = new MLContext();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void TrainModelButton_Click(object sender, RoutedEventArgs e)
    {
        // 调用训练模型的方法
        TrainModel();
    }

    private void TrainModel()
    {
        try
        {
            // 加载数据集
            IDataView trainingData = _mlContext.Data.LoadFromTextFile<ModelInput>(
                path: "./training_data.csv",
                hasHeader: true,
                separatorChar: ','
            );

            // 定义数据转换管道
            var dataProcessPipeline = _mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "Label", inputColumnName: nameof(ModelInput.Label))
                .Append(_mlContext.Transforms.Concatenate("Features", nameof(ModelInput.Feature1), nameof(ModelInput.Feature2)))
                .Append(_mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy("Label", "Features"))
                .Append(_mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            // 训练模型
            var trainedModel = _mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy(
                labelColumnName: "Label",
                featureColumnName: "Features"
            ).Fit(trainingData);

            // 保存模型
            var modelPath = "./trained_model.zip";
            _mlContext.Model.Save(trainedModel, trainingData.Schema, modelPath);

            MessageBox.Show("Model trained and saved successfully!");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}");
        }
    }
}
