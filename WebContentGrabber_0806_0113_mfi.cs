// 代码生成时间: 2025-08-06 01:13:22
// WebContentGrabber.cs
// This class is responsible for fetching content from web pages.

using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows;

namespace WebContentFetcher
{
    public class WebContentGrabber
    {
        private readonly HttpClient _httpClient;

        public WebContentGrabber()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Fetches the content of a specified URL.
        /// </summary>
        /// <param name="url">The URL to fetch content from.</param>
        /// <returns>The fetched content as a string.</returns>
        public async Task<string> FetchContentAsync(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("URL cannot be null or empty.", nameof(url));
            }

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                // Handle the exception, possibly by logging it or showing a message to the user
                MessageBox.Show($"An error occurred while fetching content: {e.Message}");
                return null;
            }
        }

        /// <summary>
        /// Extracts the text content from the HTML response.
        /// </summary>
        /// <param name="html">The HTML content to extract text from.</param>
        /// <returns>The extracted text content.</returns>
        public string ExtractTextContent(string html)
        {
            if (string.IsNullOrEmpty(html))
            {
                throw new ArgumentException("HTML content cannot be null or empty.", nameof(html));
            }

            // Use a regular expression to remove HTML tags and extract text content
            return Regex.Replace(html, "<[^>]*>