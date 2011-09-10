﻿// Copyright 2011 Max Toro Q.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Routing;

namespace MvcCodeRouting {
   
   class CodeRoutingConstraint : IRouteConstraint {

      public const string Key = "__mvccoderouting";

      public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection) {

         string valuesBaseRoute;
         string routeBaseRoute;

         if (routeDirection == RouteDirection.UrlGeneration
            && (values["controller"] as string) != null
            && (valuesBaseRoute = values[Key] as string) != null
            && (routeBaseRoute = route.DataTokens[DataTokenKeys.ControllerBaseRoute] as string) != null) {

            return String.Equals(valuesBaseRoute, routeBaseRoute, StringComparison.OrdinalIgnoreCase);
         }

         return true;
      }
   }
}
