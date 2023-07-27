# SitecoreDiscover.GenerateProductFeed
<h2>Purpose</h2>
 <p>This sample code converts the /me/product call from Sitecore OrderCloud into a TAB file as per the specficiations given at https://doc.sitecore.com/discover/en/developers/discover-developer-guide/product-data-feed-specifications.html</p>
 
 <p>The TAB file can then be used to send data to Sitecore Discover for initial bulk upload.</p>
 
 <p>The JSON file is generated from the Sitecore's PLAY! Shop demo instance by calling /me/product API call. The response of the call is stored in the JSON file.</p>
 
 <p>The /me/product call is used by the PLAY!Shop demo to display initial list of products for an anonymous user.</p>
 <p>The code is provided as-is without any warranty. This is a starting point, you will have to adjust the code and data models as per the  JSON output/response for your own shop.</p>
 <h2>How to Use</h2>
 <ol>
   <li>Clone the repository locally</li>
   <li>Open the project VS 2022 and build solution</li>
   <li>Look for the generated file in the bin/debug/data folder, make sure no code or build issues</li>
   <li>Update the data/product_data.json to match your marketplace JSON by calling /me/proudcuts via Sitecore OrderCloud developer console</li>
   <li>Re-run the code</li>
   <li>Upload the file to Sitecore Discover</li>
 </ol>
 <h2>Contribute</h2>
 <p>If you have any suggestions or ideas, open a PR request.</p>
