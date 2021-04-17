using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RecrutaTi.Application.Configurations
{
    public class CustomHealthCheckResponse
    {
    public static Task WriteHealthCheckResponse(HttpContext httpContext, HealthReport result)
    {
      httpContext.Response.ContentType = "application/json";
      JObject result1 = BuildResponseObject(result);
      //CustomHealthCheckResponse.ReportCheckStatus(result.Status, result1);
      return httpContext.Response.WriteAsync(result1.ToString(Formatting.Indented));
    }

    private static JObject BuildResponseObject(HealthReport result)
    {
      Assembly entryAssembly = Assembly.GetEntryAssembly();
      return new JObject(new object[9]
      {
        (object) new JProperty("ApplicationName", (object) entryAssembly.GetName().Name),
        (object) new JProperty("Version", (object) entryAssembly.GetName().Version.ToString()),
        (object) new JProperty("BuildDate", (object) new FileInfo(entryAssembly.Location).CreationTime),
        (object) new JProperty("MachineName", (object) Environment.MachineName),
        (object) new JProperty("Timestamp", (object) DateTime.Now),
        (object) new JProperty("OS", (object) new JObject(new object[2]
        {
          (object) new JProperty("Name", (object) Environment.OSVersion.Platform.ToString()),
          (object) new JProperty("Version", (object) Environment.OSVersion.Version.ToString())
        })),
        (object) new JProperty("status", (object) result.Status.ToString()),
        (object) new JProperty("components", (object) new JObject((object) result.Entries.Select<KeyValuePair<string, HealthReportEntry>, JProperty>((Func<KeyValuePair<string, HealthReportEntry>, JProperty>) (pair =>
        {
          string key = pair.Key;
          object[] objArray = new object[5];
          HealthReportEntry healthReportEntry;
          string str;
          if (pair.Value.Exception == null)
          {
            str = "";
          }
          else
          {
            healthReportEntry = pair.Value;
            str = healthReportEntry.Exception.ToString();
          }
          objArray[0] = (object) new JProperty("exception", (object) str);
          healthReportEntry = pair.Value;
          objArray[1] = (object) new JProperty("status", (object) healthReportEntry.Status.ToString());
          healthReportEntry = pair.Value;
          objArray[2] = (object) new JProperty("applicationName", (object) healthReportEntry.Description);
          healthReportEntry = pair.Value;
          objArray[3] = (object) new JProperty("data", (object) new JObject((object) healthReportEntry.Data.Select<KeyValuePair<string, object>, JProperty>((Func<KeyValuePair<string, object>, JProperty>) (p => new JProperty(p.Key, p.Value)))));
          healthReportEntry = pair.Value;
          objArray[4] = (object) new JProperty("ElapsedTimeInSeconds", (object) healthReportEntry.Duration.TotalSeconds);
          JObject jobject = new JObject(objArray);
          return new JProperty(key, (object) jobject);
        })))),
        (object) new JProperty("ElapsedTimeInSeconds", (object) result.TotalDuration.TotalSeconds)
      });
    }
  }
}