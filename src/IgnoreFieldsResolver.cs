using System.Collections.Generic;
using System.Reflection;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Vintagestory.API.Util;

namespace DumpJson;

public class IgnoreFieldsResolver : DefaultContractResolver {
  public readonly HashSet<string> IgnoreStrings = [];
  public IgnoreFieldsResolver(params List<string> ignore) : base() {
    NamingStrategy =
        new CamelCaseNamingStrategy() { OverrideSpecifiedNames = false };
    IgnoreStrings.AddRange(ignore);
  }

  protected override JsonProperty
  CreateProperty(MemberInfo member, MemberSerialization memberSerialization) {
    JsonProperty p = base.CreateProperty(member, memberSerialization);
    if (IgnoreStrings.Contains(member.Name)) {
      p.Ignored = true;
    }
    return p;
  }
}